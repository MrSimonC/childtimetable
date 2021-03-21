using BlazorApp.Shared;
using MudBlazor;

namespace BlazorApp.Client.Models
{
    public class TimetableItemDisplay : TimetableItem
    {
        public string Time { get; set; } = "";
        public Color Color { get; set; } = Color.Default;
    }
}
