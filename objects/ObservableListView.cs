using SSMSObjectExplorerMenu.extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace SSMSObjectExplorerMenu.objects
{
    /// <summary>
    /// Extends the standard <see cref="ListView"/> to provide an observable collection of items notifying subscribers when items are added, removed or edited.
    /// </summary>
    public class ObservableListView : ListView
    {
        /// <summary>
        /// Fired in case a list item is added, removed or edited.
        /// </summary>
        public event ObservableListViewChangedEventHandler ItemsChanged;

        public ObservableListView() : base() => this.AfterLabelEdit += OnItemEdited;

        public void AddItem_Notify(ListViewItem item)
        {
            Items.Add(item);
            ItemsChanged?.Invoke(this, new ObservableListViewChangedEventArgs(Items.Cast<ListViewItem>().ToArray(), ObservableListViewChangeType.Add));
        }

        public void RemoveItem_Notify(ICollection<ListViewItem> items)
        {
            Items.RemoveRange(items);
            ItemsChanged?.Invoke(this, new ObservableListViewChangedEventArgs(Items.Cast<ListViewItem>().ToArray(), ObservableListViewChangeType.Remove));
        }

        private void OnItemEdited(object sender, LabelEditEventArgs e) =>
            // Using BeginInvoke to ensure the edit operation is fully completed before notifying subscribers.
            this.BeginInvoke((Action)(() => ItemsChanged?.Invoke(this, new ObservableListViewChangedEventArgs(Items.Cast<ListViewItem>().ToArray(), ObservableListViewChangeType.Edit))));
    }

    public delegate void ObservableListViewChangedEventHandler(object sender, ObservableListViewChangedEventArgs e);

    public class ObservableListViewChangedEventArgs : EventArgs
    {
        public ObservableListViewChangedEventArgs(IEnumerable<ListViewItem> newItems, ObservableListViewChangeType changeType)
        {
            NewItems = newItems;
            ChangeType = changeType;
        }

        public ObservableListViewChangeType ChangeType { get; private set; }

        public IEnumerable<ListViewItem> NewItems { get; private set; }
    }

    public enum ObservableListViewChangeType
    {
        Add,
        Remove,
        Edit
    }
}
