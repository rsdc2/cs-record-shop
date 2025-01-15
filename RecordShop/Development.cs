namespace RecordShop
{
    public class Development
    {

        public static void InjectDevelopmentDataIntoDb(RecordShopDbContext dbContext)
        {
            var greatAlbum = new Album() { Title = "Great album", Artist = "Great artist"};
            if (dbContext != null)
            {
                dbContext.Albums.Add(greatAlbum);
                dbContext.SaveChanges();
                return;
            }
            throw new NullReferenceException("No database context present");
        }

        public static void InjectDevelopmentDataIntoApp(WebApplication app)
        {
            var db = app.Services.CreateScope().ServiceProvider.GetService<RecordShopDbContext>();
            InjectDevelopmentDataIntoDb(db);
            
        }
    }
}
