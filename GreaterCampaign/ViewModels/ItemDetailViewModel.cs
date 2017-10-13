using System;

namespace GreaterCampaign
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Read;
            Item = item;
        }
    }
}
