using System;

namespace PLW.Data.Model
{
    public class Paging
    {
        public Int32 PageSize { set; get; }

        public Int32 CurrentPage { set; get; }

        public Int32 RowsCount { set; get; }

        public Int32 StartRow { set; get; }
    }
}
