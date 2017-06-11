using RestaurantSystem.JsonModels.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonFilesGenerator
{
    public interface ITestObjectRandomGenerator
    {
        JsonRestaurantBranch GenerateRestaurantBranch();

        JsonAddress GenerateAddress();

        JsonCity GenerateCity();

        JsonSupplyDocument GenerateSupplyDocument();

        JsonSupplier GenerateSupplier();

        JsonSupplyDocumentComponent GenerateSupplyDocumentComponent();

        JsonWaiter GenerateWaiter();

        JsonProduct GenerateProduct();

        JsonMeasuringUnit GenerateMeasuringUnit();

        JsonSale GenerateSale();

        JsonSaleComponent GenerateSaleComponent();

        JsonMenuItem GenerateMenuItem();

        JsonMenuItemType GenerateMenuItemType();

        JsonMenuItemComponent GenerateMenuItemComponent();
    }
}
