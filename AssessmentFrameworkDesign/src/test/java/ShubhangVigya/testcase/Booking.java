package ShubhangVigya.testcase;

import java.util.HashMap;

import org.testng.Assert;
import org.testng.annotations.Test;

import ShubhangVigya.pageobjects.BookingConfirmation;
import ShubhangVigya.pageobjects.BookingPage;
import ShubhangVigya.pageobjects.LandingPage;
import ShubhangVigya.pageobjects.LoginPage;
import ShubhangVigya.reusableComponent.BaseTest;

public class Booking extends BaseTest {

	@Test(dataProvider = "getData", dataProviderClass = DataFile.class, groups = { "Regression" })
	public void bookAppointmentMedicare(HashMap<String, String> input) {

		// Initialize Chrome driver and catch Landing Page
		LandingPage landingPage = initializeDriver();

		LoginPage loginPage = landingPage.landingApplication();

		// Enter User Credentials and catch next page
		BookingPage bookingPage = loginPage.loginApplication(input.get("userName"), input.get("password"));

		// Create Appointment Booking and catch next page
		BookingConfirmation bookingConfirmation = bookingPage.bookingApplicationMedicare(input.get("comment"));

		// Catch Booking Text into string variable
		String facility = bookingConfirmation.getFacilityText();
		String program = bookingConfirmation.getProgramText();

		// Assert String Match for Booking
		Assert.assertTrue(facility.equalsIgnoreCase("Seoul CURA Healthcare Center"));
		Assert.assertTrue(program.equalsIgnoreCase("Medicare"));

	}

	@Test(dataProvider = "getData", dataProviderClass = DataFile.class, groups = { "Regression" })
	public void bookAppointmentMedicaid(HashMap<String, String> input) {

		// Initialize Chrome driver and catch Landing Page
		LandingPage landingPage = initializeDriver();

		LoginPage loginPage = landingPage.landingApplication();

		// Enter User Credentials and catch next page
		BookingPage bookingPage = loginPage.loginApplication(input.get("userName"), input.get("password"));

		// Create Appointment Booking and catch next page
		BookingConfirmation bookingConfirmation = bookingPage.bookingApplicationMedicaid(input.get("comment"));

		// Catch Booking Text into string variable
		String facility = bookingConfirmation.getFacilityText();
		String program = bookingConfirmation.getProgramText();

		// Assert String Match for Booked Facility and Booked Program
		Assert.assertTrue(facility.equalsIgnoreCase("Seoul CURA Healthcare Center"));
		Assert.assertTrue(program.equalsIgnoreCase("Medicaid"));

	}

	@Test(dataProvider = "getData", dataProviderClass = DataFile.class)
	public void bookAppointmentNone(HashMap<String, String> input) {

		// Initialize Chrome driver and catch Landing Page
		LandingPage landingPage = initializeDriver();

		LoginPage loginPage = landingPage.landingApplication();

		// Enter User Credentials and catch next page
		BookingPage bookingPage = loginPage.loginApplication(input.get("userName"), input.get("password"));

		// Create Appointment Booking and catch next page
		BookingConfirmation bookingConfirmation = bookingPage.bookingApplicationNone(input.get("comment"));

		// Catch Booking Text into string variable
		String facility = bookingConfirmation.getFacilityText();
		String program = bookingConfirmation.getProgramText();

		// Assert String Match for Booked Facility and Booked Program
		Assert.assertTrue(facility.equalsIgnoreCase("Seoul CURA Healthcare Center"));
		Assert.assertTrue(program.equalsIgnoreCase("None"));

	}

}
