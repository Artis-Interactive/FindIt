using System.Globalization;

namespace findit_backend.Models
{
    public class AddressModel
    {
        public string? Province { get; set; }
        public string? Canton { get; set; }
        public string? District { get; set; }
        public string? Details { get; set; }
        public string Coords { get; set; }
    }
}
