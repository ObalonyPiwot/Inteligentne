using Domain.Entities;
using MyProject.Application.Features.Common.Queries;
using MyProject.Application.Features.Common;
using MyProject.Application.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Persistance.Context;
using AutoMapper;
using MyProject.Persistance.Middlewares;
using MyProject.Persistance.Authorization;
using Microsoft.EntityFrameworkCore;
using Azure;
using System.Net;
using Newtonsoft.Json;

namespace Application.Features.Products.Queries.GetRecommendedPageableProducts
{
    public class GetRecommendedPageableProductsQueryHandler : BaseQueryHandler<ProductEntity, GetRecommendedPageableProductsQuery, PaginationResult<ProductViewModel>>
    {
        public ICurrentUser _currentUser { get; set; }

        public GetRecommendedPageableProductsQueryHandler(IMyProjectDbContext dbContext, IMapper mapper, ICurrentUser currentUser) : base(dbContext, mapper)
        {
            _currentUser = currentUser;
        }

        public override async Task<BaseResponse<PaginationResult<ProductViewModel>>> Handle(GetRecommendedPageableProductsQuery request, CancellationToken cancellationToken)
        {
            var userCarts = await DbContext.Carts.Where(x => x.UserId == _currentUser.Id)
                                                 .OrderByDescending(x => x.Created)
                                                 .Take(10)
                                                 .ToListAsync();

            var productsIdsStrings = userCarts.Select(x => x.ProductIds).ToList();
            var productIdsList = new List<int>();

            foreach (var element in productsIdsStrings)
            {
                var tmp = element.Split(",").ToList();
                if(tmp.ElementAt(0)!="")
                    productIdsList.AddRange(tmp.Select(int.Parse));
            }
            //var productIdsList = new List<int>() { 1, 2, 3, 4 };

            var result = await AskOpenAI(productIdsList);
            var paginationResult = new PaginationResult<ProductViewModel>(result, result.Count());

            return new BaseResponse<PaginationResult<ProductViewModel>>(HttpStatusCode.OK, paginationResult);
        }

        public class RecommendedProduct
        {
            public int Id { get; set; }
            public string Description { get; set; }
        }

        public async Task<IEnumerable<ProductViewModel>> AskOpenAI(IEnumerable<int> productIdsList)
        {
            var allProductsDetails = await GetAllProductsDetails();
            var purchasedProductsDetails = await GetPurchasedProductsDetails(productIdsList);
            var recommendedProductsList = await GetRecommendedProductsFromOpenAI(allProductsDetails, purchasedProductsDetails);
            var recommendedProductEntities = await GetRecommendedProductsFromDatabase(recommendedProductsList);

            return MapToViewModel(recommendedProductEntities, recommendedProductsList);
        }

        private async Task<List<ProductDetails>> GetAllProductsDetails()
        {
            var allProducts = await DbContext.Products
                                   .Include(p => p.Brand)
                                   .Include(p => p.ProductCategory)
                                   .Include(p => p.ProductSeason)
                                   .Include(p => p.ProductMaterial)
                                   .ToListAsync();
            return allProducts.Select(p => new ProductDetails
            {
                ProductName = p.Name,
                ProductDescription = p.Description,
                ProductPrice = p.Price,
                BrandName = p.Brand?.Name,
                CategoryName = p.ProductCategory?.Name,
                SeasonName = p.ProductSeason?.Name,
                MaterialName = p.ProductMaterial?.Name
            }).ToList();
        }

        private async Task<List<ProductDetails>> GetPurchasedProductsDetails(IEnumerable<int> productIdsList)
        {
            var purchasedProducts = await DbContext.Products
                                                   .Include(p=>p.Brand)
                                                   .Include(p=>p.ProductCategory)
                                                   .Include(p=>p.ProductSeason)
                                                   .Include(p=>p.ProductMaterial)
                                                   .Where(p => productIdsList.Contains(p.Id))
                                                   .ToListAsync();
            return purchasedProducts.Select(p => new ProductDetails
            {
                ProductName = p.Name,
                ProductDescription = p.Description,
                ProductPrice = p.Price,
                BrandName = p.Brand?.Name,
                CategoryName = p.ProductCategory?.Name,
                SeasonName = p.ProductSeason?.Name,
                MaterialName = p.ProductMaterial?.Name
            }).ToList();
        }

        private async Task<List<RecommendedProduct>> GetRecommendedProductsFromOpenAI(List<ProductDetails> allProductsDetails, List<ProductDetails> purchasedProductsDetails)
        {
            /* var apiKey = "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";
             var apiUrl = "https://api.openai.com/v1/chat/completions";

             using var client = new HttpClient();
             client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

             var requestBody = new
             {
                 model = "gpt-3.5-turbo",
                 messages = new[]
                 {
                     new { role = "system", content = "Jesteś pomocnym asystentem do rekomendacji produktów na podstawie historii zakupów użytkownika oraz całego katalogu produktów." },
                     new {
                         role = "user",
                         content = $"Oto produkty, które użytkownik kupił: {JsonConvert.SerializeObject(purchasedProductsDetails)}. Oto pełna lista dostępnych produktów: {JsonConvert.SerializeObject(allProductsDetails)}. " +
                                   "Odpowiedź powinna zawierać listę 4 obiektów w formacie JSON, gdzie każdy obiekt ma pola 'id' oraz 'description'. " +
                                   "Id to identyfikator produktu, a description to krótki opis, dlaczego ten produkt został zarekomendowany użytkownikowi." +
                                   "Oczekiwana odpowiedź powinna mieć format podobny do tej: " +
                                   "[ " +
                                   "{ \"id\": 1, \"description\": \"Lubisz produkty w podobnej cenie\" }, " +
                                   "{ \"id\": 22, \"description\": \"Ostatnio kupowałeś produkty tej marki\" }," +
                                   " ..." +
                                   " ]"
                     }
                 },
                 max_tokens = 1500,
                 temperature = 0.7
             };

             var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
             var response = await client.PostAsync(apiUrl, content);
             var responseString = await response.Content.ReadAsStringAsync();

             var openAiResponse = JsonConvert.DeserializeObject<dynamic>(responseString);
             var recommendedProducts = openAiResponse?.choices?[0]?.message?.content?.ToString();*/
            var recommendedProducts = @"[
                {""id"": 10, ""description"": ""Lubisz produkty tej marki""},
                {""id"": 26, ""description"": ""Podobne produkty z tej samej kategorii""},
                {""id"": 29, ""description"": ""Ostatnio kupowane produkty z podobnym materiałem""},
                {""id"": 50, ""description"": ""Podobne produkty z tej samej kategorii""}
            ]";
            var recommendedProductsList = JsonConvert.DeserializeObject<List<RecommendedProduct>>(recommendedProducts);
            return recommendedProductsList;
        }

        private async Task<List<ProductEntity>> GetRecommendedProductsFromDatabase(List<RecommendedProduct> recommendedProductsList)
        {
            var recommendedProductIds = recommendedProductsList.Select(x => x.Id).ToList();
            return await DbContext.Products
                                   .Include(p => p.Brand)
                                   .Include(p => p.ProductCategory)
                                   .Include(p => p.ProductSeason)
                                   .Include(p => p.ProductMaterial)
                                   .Where(p => recommendedProductIds.Contains(p.Id))
                                   .ToListAsync();
        }

        private IEnumerable<ProductViewModel> MapToViewModel(List<ProductEntity> recommendedProductEntities, List<RecommendedProduct> recommendedProductsList)
        {
            var models = Mapper.Map<IEnumerable<ProductViewModel>>(recommendedProductEntities);
            foreach (var model in models)
            {
                model.RecomendationDescription = recommendedProductsList.First(x => model.Id == x.Id).Description;
            }
            return models;
        }
    }
    public class ProductDetails {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public float ProductPrice { get; set; }
        public string? ProductLikeCount { get; set; }
        public string? BrandName { get; set; }
        public string? CategoryName { get; set; }
        public string? SeasonName { get; set; }
        public string? MaterialName { get; set; }
    }

}
