namespace RestaurantSystem.DataImporter.SupplyDocumentImporter.Components
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.DataImporter.SupplyDocumentImporter.Abstraction;
    using RestaurantSystem.Infrastructure.Constants;
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MeasuringUnitImporter : BaseImporter, IImporter
    {
        public int Order => 5;

        public Action<IRestaurantSystemData, IList<SupplyDocument>> Import
        {
            get
            {
                return (db, documents) =>
                {
                    var measuringUnits = ExtractMeasuringUnits(documents);

                    for (int i = 0; i < measuringUnits.Count; i++)
                    {
                        if (!MeasuringUnitExists(measuringUnits[i], db))
                        {
                            db.MeasuringUnits.Add(new MeasuringUnit
                            {
                                Name = measuringUnits[i].Name
                            });
                        }

                        this.SaveChanges(i, db);
                    }

                    db.SaveChanges();
                };
            }
        }

        private bool MeasuringUnitExists(MeasuringUnit unit, IRestaurantSystemData db)
        {
            var dbMeasuringUnit = db.MeasuringUnits
                .All()
                .Where(x => x.Name == unit.Name)
                .FirstOrDefault();

                var result = dbMeasuringUnit != null;

            return result;
        }

        private List<MeasuringUnit> ExtractMeasuringUnits(IList<SupplyDocument> documents)
        {
            var result = new List<MeasuringUnit>();

            foreach (var doc in documents)
            {
                foreach (var component in doc.SupplyDocumentComponents)
                result.Add(component.Product.MeasuringUnit);
            }

            return result;
        }
    }
}
