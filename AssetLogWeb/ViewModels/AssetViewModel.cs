using AssetLogWeb.Models;

namespace AssetLogWeb.ViewModels
{
    public class AssetViewModel
    {
        public Asset Asset { get; set; }

        public bool CheckForIsServiced { get; set; }
    }
}
