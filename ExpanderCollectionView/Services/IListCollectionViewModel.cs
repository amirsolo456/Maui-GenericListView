using ExpanderCollectionView.Models.ExpanderHeader;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpanderCollectionView.Services
{
    public interface IListCollectionViewModel
    {
        ObservableCollection<ExpanderHeader> DisplayItems { get; }
    }
}

