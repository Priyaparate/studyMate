namespace StudyMateLibrary.FrameWork
{
    public class Entitydeclarations
    {
        public bool CascadeDelete { get; set; }
        public bool ProjectOnly { get; set; }

        public Entitydeclarations()
        {
            CascadeDelete = false;
            ProjectOnly = false;
        }
    }
}