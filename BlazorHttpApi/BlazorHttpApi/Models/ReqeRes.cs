using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorHttpApi.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        public string Avatar { get; set; }
    }

    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }
    }

    public class ReqResResponse
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<Person> data { get; set; }
        public Support support { get; set; }
    }

    public class ReqResRequest
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string job { get; set; }
    }

    public class ReqResCreateResponse
    {
        public string name { get; set; }
        public string job { get; set; }
        public string id { get; set; }
        public string createdAt { get; set; }
    }

}
