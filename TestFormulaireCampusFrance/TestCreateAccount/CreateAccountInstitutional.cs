using CampusFrance.test.Functions;
using CampusFrance.test.ObjectClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CampusFrance.test.TestCreateAccount
{
    [TestFixture]
    public class CreateAccountInstitutional
    {

        public IWebDriver driver;
        public IWebElement dropdownInput;
        public List<User> users;

        [SetUp]
        public void Setup()
        {
            //Instanciation 
            driver = new ChromeDriver();
            users = ReadDataFromJson.FromJsonFileToObject();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }



        [Test]
        public void AccountInstitutionalEntreprise()
        {
            driver.Navigate().GoToUrl("https://www.campusfrance.org/fr/user/register");

            //Renseigner les champs de saisie du formulaire
            //Informations de connexion
            driver.FindElement(By.XPath("//input[@placeholder='monadresse@domaine.com']")).SendKeys(users[4].AdresseMail);
            driver.FindElement(By.CssSelector("#edit-pass-pass1")).SendKeys(users[4].MotDePasse);
            driver.FindElement(By.CssSelector("#edit-pass-pass2")).SendKeys(users[4].MotDePasse);


            //Informations personnelles
            driver.FindElement(By.Id("tarteaucitronPersonalize2")).Click(); // Accepter cookies
            driver.FindElement(By.CssSelector("label[for='edit-field-civilite-mr']")).Click();
            driver.FindElement(By.Id("edit-field-nom-0-value")).SendKeys(users[4].Nom);
            driver.FindElement(By.Id("edit-field-prenom-0-value")).SendKeys(users[4].Prenom);

            //Selectionner le pays de résidence
            // C'est un Input et pas un Select = récupere l'element, vider le champ, taper le pays, et entrer
            dropdownInput = driver.FindElement(By.Id("edit-field-pays-concernes-selectized"));
            dropdownInput.SendKeys(Keys.Backspace);
            dropdownInput.SendKeys(users[4].PaysResidence);
            dropdownInput.SendKeys(Keys.Enter);


            driver.FindElement(By.Id("edit-field-nationalite-0-target-id")).SendKeys(users[4].PaysNationalite);
            driver.FindElement(By.Id("edit-field-code-postal-0-value")).SendKeys(users[4].Adresse.CodePostale);
            driver.FindElement(By.Id("edit-field-ville-0-value")).SendKeys(users[4].Adresse.Ville);
            driver.FindElement(By.Id("edit-field-telephone-0-value")).SendKeys(users[4].Telephone);

            //Informations complémentaire
            //Scroller  avant de cocher le bouton radio  Institutional
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true); arguments[0].click();",
                       driver.FindElement(By.Id("edit-field-publics-cibles-4")));

            driver.FindElement(By.Id("edit-field-fonction-0-value")).SendKeys(users[4].Fonction);



            // C'est un Input et pas un Select = récupere l'element, vider le champ, taper le pays, et entrer


            dropdownInput = driver.FindElement(By.Id("edit-field-type-organisme-selectized"));
            dropdownInput.SendKeys(Keys.Backspace);
            dropdownInput.SendKeys(users[4].TypeOrganisme);
            dropdownInput.SendKeys(Keys.Enter);

            driver.FindElement(By.Id("edit-field-nom-organisme-0-value")).SendKeys(users[4].NomOrganisme);



            //driver.FindElement(By.XPath("//*[@id=\"edit-field-accepte-communications-value\"]")).Click();
            // Vérifier que le label du bouton de validation du formulaire
            Assert.AreEqual("Créer un compte", driver.FindElement(By.Id("edit-submit")).GetAttribute("value"));


            // Vérifier que le statut sélectionné est "institutionnel"
            Assert.IsTrue(driver.FindElement(By.Id("edit-field-publics-cibles-4")).Selected, "Le bouton 'Institutionnel' n'est pas sélectionné.");

            // Vérifier que le niveau sélectionné est "Entreprise", recupere le text de l'item qui est le text selectionner
            Assert.AreEqual("Entreprise", driver.FindElement(By.CssSelector("#edit-field-type-organisme-wrapper > div > div > div.selectize-input.items.has-options.full.has-items > div")).Text);
        }


        [Test]
        public void AccountInstitutionalUniversity()
        {
            driver.Navigate().GoToUrl("https://www.campusfrance.org/fr/user/register");

            //Renseigner les champs de saisie du formulaire
            //Informations de connexion
            driver.FindElement(By.XPath("//input[@placeholder='monadresse@domaine.com']")).SendKeys(users[5].AdresseMail);
            driver.FindElement(By.CssSelector("#edit-pass-pass1")).SendKeys(users[5].MotDePasse);
            driver.FindElement(By.CssSelector("#edit-pass-pass2")).SendKeys(users[5].MotDePasse);


            //Informations personnelles
            driver.FindElement(By.Id("tarteaucitronPersonalize2")).Click(); // Accepter cookies
            driver.FindElement(By.CssSelector("label[for='edit-field-civilite-mr']")).Click();
            driver.FindElement(By.Id("edit-field-nom-0-value")).SendKeys(users[5].Nom);
            driver.FindElement(By.Id("edit-field-prenom-0-value")).SendKeys(users[5].Prenom);

            //Selectionner le pays de résidence
            // C'est un Input et pas un Select = récupere l'element, vider le champ, taper le pays, et entrer
            dropdownInput = driver.FindElement(By.Id("edit-field-pays-concernes-selectized"));
            dropdownInput.SendKeys(Keys.Backspace);
            dropdownInput.SendKeys(users[5].PaysResidence);
            dropdownInput.SendKeys(Keys.Enter);


            driver.FindElement(By.Id("edit-field-nationalite-0-target-id")).SendKeys(users[5].PaysNationalite);
            driver.FindElement(By.Id("edit-field-code-postal-0-value")).SendKeys(users[5].Adresse.CodePostale);
            driver.FindElement(By.Id("edit-field-ville-0-value")).SendKeys(users[5].Adresse.Ville);
            driver.FindElement(By.Id("edit-field-telephone-0-value")).SendKeys(users[5].Telephone);

            //Informations complémentaire
            //Scroller  avant de cocher le bouton radio  Institutional
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true); arguments[0].click();",
                       driver.FindElement(By.Id("edit-field-publics-cibles-4")));

            driver.FindElement(By.Id("edit-field-fonction-0-value")).SendKeys(users[5].Fonction);



            // C'est un Input et pas un Select = récupere l'element, vider le champ, taper le pays, et entrer


            dropdownInput = driver.FindElement(By.Id("edit-field-type-organisme-selectized"));
            dropdownInput.SendKeys(Keys.Backspace);
            dropdownInput.SendKeys(users[5].TypeOrganisme);
            dropdownInput.SendKeys(Keys.Enter);

            driver.FindElement(By.Id("edit-field-nom-organisme-0-value")).SendKeys(users[5].NomOrganisme);



            //driver.FindElement(By.XPath("//*[@id=\"edit-field-accepte-communications-value\"]")).Click();
            // Vérifier que le label du bouton de validation du formulaire
            Assert.AreEqual("Créer un compte", driver.FindElement(By.Id("edit-submit")).GetAttribute("value"));


            // Vérifier que le statut sélectionné est "institutionnel"
            Assert.IsTrue(driver.FindElement(By.Id("edit-field-publics-cibles-4")).Selected, "Le bouton 'Institutionnel' n'est pas sélectionné.");

            // Vérifier que le niveau sélectionné est "Etablissement-Université-Ecole", recupere le text de l'item qui est le text selectionner
            Assert.AreEqual("Etablissement-Université-Ecole", driver.FindElement(By.CssSelector("#edit-field-type-organisme-wrapper > div > div > div.selectize-input.items.has-options.full.has-items > div")).Text);

        }
    }
}
