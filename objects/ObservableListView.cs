using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace SSMSObjectExplorerMenu.objects
{
    /// <summary>
    /// Extends the standard <see cref="ListView"/> to provide an observable collection of items notifying subscribers when items are added or removed.
    /// </summary>
    public class ObservableListView : ListView
    {
        /// <summary>
        /// New item has been inserted in the ListView (ANSI).
        /// </summary>
        private const int LVM_INSERTITEM_A = 0x1007;
        /// <summary>
        /// New item has been inserted in the ListView (Unicode).
        /// </summary>
        private const int LVM_INSERTITEM_W = 0x104D;
        /// <summary>
        /// An item has been removed from the ListView.
        /// </summary>
        private const int LVM_DELETEITEM = 0x1008;

        public event ObservableListViewChangedEventHandler ItemsChanged;

        public ObservableListView() : base() => this.AfterLabelEdit += OnItemEdited; // handling LVN_ENDLABELEDIT notification

        protected override void WndProc(ref Message wndMsg)
        {
            base.WndProc(ref wndMsg);

            switch (wndMsg.Msg)
            {
                case LVM_INSERTITEM_A:
                case LVM_INSERTITEM_W:
                    ItemsChanged?.Invoke(this, new ObservableListViewChangedEventArgs(Items.Cast<ListViewItem>(), ObservableListViewChangeType.Add));
                    break;
                case LVM_DELETEITEM: // called before the item is actually removed
                    var elements = Items.Cast<ListViewItem>();
                    Debug.WriteLine($"[REMOVE-IN-WNDPROC] Number of distinct elements: {elements.Count()}");
                    unsafe
                    {
                        int x = 0;
                        foreach (var i in elements)
                        {
                            Debug.WriteLine($"Item[{x}]: addr {(long)&i:X}, hash {System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(i)}");
                            x++;
                        }
                    }
                    var itemRemoveTarget = Items[wndMsg.WParam.ToInt32()];
                    ItemsChanged?.Invoke(this, new ObservableListViewChangedEventArgs(Items.Cast<ListViewItem>().Where(i => i != itemRemoveTarget), ObservableListViewChangeType.Remove));
                    break;
            }
        }

        private void OnItemEdited(object sender, LabelEditEventArgs e) =>
            // Using BeginInvoke to ensure the edit operation is fully completed before notifying subscribers.
            this.BeginInvoke((Action)(() => ItemsChanged?.Invoke(this, new ObservableListViewChangedEventArgs(Items.Cast<ListViewItem>(), ObservableListViewChangeType.Edit))));
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
        Edit,
        Clear
    }
}
