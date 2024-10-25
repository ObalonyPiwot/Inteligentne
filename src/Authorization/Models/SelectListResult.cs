using System;

namespace MyProject.AuthorizationServer.Models
{
    public class SelectlistResult
    {
        public SelectlistResult() { }
        public SelectlistResult(Guid id, string label)
        {
            Id = id;
            Label = label;
        }

        public Guid Id { get; set; }
        public string Label { get; set; } = null!;
    }
}
