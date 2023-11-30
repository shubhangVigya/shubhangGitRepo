package ShubhangVigya;

import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.util.HashMap;
import java.util.List;

import org.testng.Assert;
import org.testng.AssertJUnit;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import ShubhangVigya.TestComponent.BaseTest;
import pageObject.CartPage;
import pageObject.CheckoutPage;
import pageObject.ConfirmationPage;
import pageObject.OrderPage;
import pageObject.ProductCatalogue;



public class StandloneTest extends BaseTest {
	//public static void main(String[] args) {
	String productName = "ZARA COAT 3";

	@Test(dataProvider="getData",groups= {"Purchase"})
	public void submitOrder(HashMap<String,String> input) throws IOException , InterruptedException
	{
	
	 

	landingpage.loginApplication(input.get("email"),input.get("password"));
	ProductCatalogue productCatalogue = new ProductCatalogue(driver);
	productCatalogue.ProductList();
	productCatalogue.addProductToCart(input.get("productName"));
	CartPage cartPage = productCatalogue.goToCart();
	
	//CartPage cartPage = new CartPage(driver);
	Boolean match = cartPage.VerifyProductDisplay(input.get("productName"));
	Assert.assertTrue(match);
	CheckoutPage checkoutpage = cartPage.Checkout();
	checkoutpage.SelectCountry("India");
ConfirmationPage confirmationPage = checkoutpage.Submit();

String confirmMessage = confirmationPage.ValidateText();

AssertJUnit.assertTrue(confirmMessage.equalsIgnoreCase("THANKYOU FOR THE ORDER."));
	}
	

//	@Test(dependsOnMethods= {"submitOrder"})
//	public void OrderHistoryTest()
//	{
//		//"ZARA COAT 3";
//		landingpage.loginApplication("anshika@gmail.com", "Iamking@000");
//		ProductCatalogue productCatalogue = new ProductCatalogue(driver);
//		OrderPage ordersPage = productCatalogue.goToOrderPage();
//		Assert.assertTrue(ordersPage.VerifyOrderDisplay(productName));

//}
	
//	@DataProvider
//	public Object [] [] getData()
//	{
//		return new Object [][] {{"anshika@gmail.com","Iamking@000","ZARA COAT 3"},{"shetty@gmail.com","Iamking@000","ADIDAS ORIGINAL"}};
//	}
	
	@DataProvider
	public Object [] [] getData() throws IOException
	{
		HashMap <String,String> map = new HashMap<String,String>();
		map.put("email", "anshika@gmail.com");
		map.put("password", "Iamking@000");
		map.put("productName", "ZARA COAT 3");
		
		HashMap <String,String> map1 = new HashMap<String,String>();
		map1.put("email", "shetty@gmail.com");
		map1.put("password", "Iamking@000");
		map1.put("productName", "ADIDAS ORIGINAL");
//		List<HashMap<String,String>> data = getJsonDataToMap(System.getProperty("user.dir")+"//Users//shubhangvigya//Desktop//Java Workspace//SeleniumFrameworkDesign//src//test//java//ShubhangVigya//data//PurchaseOrder.json");
	return new Object [][] {{map},{map1}};
	}
}
