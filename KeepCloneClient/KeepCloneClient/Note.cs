using System;

namespace KeepCloneClient
{
    public partial class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Diaryid { get; set; }
        public string Notecontent { get; set; }
    }
}