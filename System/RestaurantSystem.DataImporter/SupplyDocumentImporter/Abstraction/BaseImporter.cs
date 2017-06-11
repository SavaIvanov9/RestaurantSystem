namespace RestaurantSystem.DataImporter.SupplyDocumentImporter.Abstraction
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Infrastructure.Constants;
    using System;

    public abstract class BaseImporter
    {
        private int saveChangesCount = 50;

        protected void SaveChanges(int count, IRestaurantSystemData db)
        {
            if (count % saveChangesCount == 0)
            {
                for (int i = 0; i <= GlobalConstants.SaveChangesRetryCountIfError; i++)
                {
                    try
                    {
                        db.SaveChanges();
                        break;
                    }
                    catch (Exception ex)
                    {
                        //TO DO 
                        // Handle  exception when postgre error logs db is ready
                    }
                }
            }
        }
    }
}
