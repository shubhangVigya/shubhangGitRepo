package daft.pageobjects;

import java.util.List;

import org.openqa.selenium.By;
import org.openqa.selenium.StaleElementReferenceException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;

import daft.AbstractComponents.AbstractComponent;

public class BuyPage extends AbstractComponent {

	WebDriver driver;
	List<WebElement> filterResults;

	public BuyPage(WebDriver driver) {
		super(driver); //Initialize driver in parent class
		this.driver = driver; //Initialize driver from TestClass

		PageFactory.initElements(driver, this);

	}

	// Buy page Locators written in page factory design pattern
	@FindBy(css = ".iWPGnb")
	List<WebElement> listResults;

	By listResultsBy = By.cssSelector(".iWPGnb");

	@FindBy(xpath = "//div[@class='NewButtonstyled__ButtonContentContainer-c5tcz6-0 iHKbuv']//span[text()='Filters']")
	WebElement filter;

	By filterBy = By
			.xpath("//div[@class='NewButtonstyled__ButtonContentContainer-c5tcz6-0 iHKbuv']//span[text()='Filters']");

	@FindBy(xpath = "//input[@id='keywordtermsModal']")
	WebElement keyword;

	@FindBy(xpath = "//button[@class='NewButtonstyled__StyledButton-c5tcz6-4 hfRLhD']/div/span")
	WebElement show;

	@FindBy(xpath = "//li[@class='SearchPagestyled__Result-v8jvjf-2 iWPGnb']")
	List<WebElement> filterResultsEle;

	By filterResultsBy = By.xpath("//li[@class='SearchPagestyled__Result-v8jvjf-2 iWPGnb']");

	// capture results for selected county
	public List<WebElement> searchResult() {
		waitForElementToAppear(listResultsBy);// Explicit Wait of 4 sec
		List<WebElement> searchResults = listResults;
		return searchResults;

	}

	public void filterTab() throws InterruptedException {
		// waitForElementToAppear(filterBy);
		Thread.sleep(14000); // hard stop of 14 sec
		filter.click(); // click on filters button

	}
    // Populate Keyword under Filters
//	public void filterKeyword(String Keyword) {
//		keyword.sendKeys(Keyword);
//		show.click();
//
//	}
	
	public void filterKeyword(String Keyword) {
	    keyword.sendKeys(Keyword);
	    try {
	        show.click();
	    } catch (StaleElementReferenceException e) {
	        // If StaleElementReferenceException occurs, refresh the WebElement
	        show = driver.findElement(By.xpath("//button[@class='NewButtonstyled__StyledButton-c5tcz6-4 hfRLhD']/div/span"));
	        show.click();
	    }
	}

	
    // capture results of given keyword under filters
	public List<WebElement> filterList() throws InterruptedException {
		// waitForElementToAppear(filterResultsBy);
		Thread.sleep(4000);
		filterResults = filterResultsEle;

		return filterResults;
	}
    // Captures & click on first showed reult and return next page
	public AdvertPage advert() {
		WebElement firstResult = filterResults.get(0);
		firstResult.click();
		AdvertPage advertPage = new AdvertPage(driver);
		return advertPage;

	}

}
