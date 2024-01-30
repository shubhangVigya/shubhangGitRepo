package daftIeTests;

import java.util.HashMap;
import java.util.List;

import org.openqa.selenium.WebElement;
import org.testng.Assert;
import org.testng.annotations.Test;

import daft.TestComponent.BaseTest;
import daft.pageobjects.AdvertPage;
import daft.pageobjects.BuyPage;
import daft.pageobjects.LandingPage;

public class FilterTest extends BaseTest {

	// Scenario 1: Verify results for county Dublin
	@Test(dataProvider = "getData", dataProviderClass = DataFile.class, enabled = true)
	public void VerifyCounty(HashMap<String, String> input) throws InterruptedException {

		// Initialize Chrome driver and catch Landing Page
		LandingPage landingPage = initializeDriver();

		// Search given county and catch BuyPage
		BuyPage buyPage = landingPage.Search(input.get("County"));

		// BuyPage buyPage = new BuyPage(driver);

		// catch all the county result in a list
		List<WebElement> searchResults = buyPage.searchResult();

		// Assertion to check search results for searched County
		Assert.assertTrue(searchResults.size() > 0, "No search results found for " + input.get("County"));
	}

	// Scenario 2: Verify results for filter Keyword
	@Test(dataProvider = "getData", dataProviderClass = DataFile.class, enabled = true)
	public void VerifyKeywordResult(HashMap<String, String> input) throws InterruptedException {

		LandingPage landingPage = initializeDriver();

		BuyPage buyPage = landingPage.Search(input.get("County"));

		// BuyPage buyPage = new BuyPage(driver);

		buyPage.filterTab();
		buyPage.filterKeyword(input.get("Keyword"));
		// catch all the filter result of "garage" keyword
		List<WebElement> filterResults = buyPage.filterList();

		// Assertion to check filter keyword results
		Assert.assertTrue(filterResults.size() > 0, "No search results found for " + input.get("Keyword"));
	}

	// Scenario 3: Verify filter keyword in Advert
	@Test(dataProvider = "getData", dataProviderClass = DataFile.class, groups = { "Regression" })
	public void VerifyKeywordText(HashMap<String, String> input) throws InterruptedException {

		LandingPage landingPage = initializeDriver();

		BuyPage buyPage = landingPage.Search(input.get("County"));

		// BuyPage buyPage = new BuyPage(driver);

		buyPage.filterTab();
		buyPage.filterKeyword(input.get("Keyword"));

		buyPage.filterList();
		// Click on first advert and catch Advert page
		AdvertPage advertPage = buyPage.advert();

		// AdvertPage advertPage = new AdvertPage(driver);
		String text = advertPage.wordScan();

		// Assertion to check keyword in Advert
		Assert.assertTrue(text.toLowerCase().contains(input.get("Keyword"))|| text.toUpperCase().contains(input.get("Keyword")),
				input.get("Keyword") + " not found in advert.");

	}

}
