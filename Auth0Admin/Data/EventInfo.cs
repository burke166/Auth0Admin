using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Auth0Admin.Data
{
    public class EventInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string FeaturedImageUrl { get; set; }
        internal string _ImageUrls { get; set; }
        [NotMapped]
        public List<string> ImageUrls
        {
            get
            {
                return string.IsNullOrWhiteSpace(_ImageUrls) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(_ImageUrls);
            }
            set
            {
                _ImageUrls = JsonSerializer.Serialize(value);
            }
        }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        [NotMapped]
        public string Date
        {
            get => DateTime.ToShortDateString();
        }
        [NotMapped]
        public string Time
        {
            get => DateTime.ToShortTimeString();
        }
    }
}
