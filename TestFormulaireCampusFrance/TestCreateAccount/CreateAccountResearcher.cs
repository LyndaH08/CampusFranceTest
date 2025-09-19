using CampusFrance.test.Functions;
using CampusFrance.test.ObjectClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace CampusFrance.test.TestCreateAccount
{
    [TestFixture]
    public  class CreateAccountResearcher
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
        public void AccountReseacherLicence2Sport()
        {
            driver.Navigate().GoToUrl("https://www.campusfrance.org/fr/user/register");

            //Renseigner les champs de saisie du formulaire
            //Informations de connexion
            driver.FindElement(By.XPath("//input[@placeholder='monadresse@domaine.com']")).SendKeys(users[2].AdresseMail);
            driver.FindElement(By.CssSelector("#edit-pass-pass1")).SendKeys(users[2].MotDePasse);
            driver.FindElement(By.CssSelector("#edit-pass-pass2")).SendKeys(users[2].MotDePasse);

            //Informations personnelles
            driver.FindElement(By.Id("tarteaucitronPersonalize2")).Click(); // Accepter cookies

          ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true); arguments[0].click();",
                      driver.FindElement(By.Id("edit-field-civilite-mr")));
            

            driver.FindElement(By.Id("edit-field-nom-0-value")).SendKeys(users[2].Nom);
            driver.FindElement(By.Id("edit-field-prenom-0-value")).SendKeys(users[2].Prenom);

            //Selectionner le pays de résidence
            // C'est un Input et pas un Select = récupere l'element, vider le champ, taper le pays, et entrer
            dropdownInput = driver.FindElement(By.Id("edit-field-pays-concernes-selectized"));
            dropdownInput.SendKeys(Keys.Backspace);
            dropdownInput.SendKeys(users[2].PaysResidence);
            dropdownInput.SendKeys(Keys.Enter);


            driver.FindElement(By.Id("edit-field-nationalite-0-target-id")).SendKeys(users[2].PaysNationalite);
            driver.FindElement(By.Id("edit-field-code-postal-0-value")).SendKeys(users[2].Adresse.CodePostale);
            driver.FindElement(By.Id("edit-field-ville-0-value")).SendKeys(users[2].Adresse.Ville);
            driver.FindElement(By.Id("edit-field-telephone-0-value")).SendKeys(users[2].Telephone);

            //Informations complémentaire
            //Scroller  avant de cocher le bouton radio  Chercheur
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true); arguments[0].click();",
                       driver.FindElement(By.Id("edit-field-publics-cibles-3")));


            // C'est un Input et pas un Select = récupere l'element, vider le champ, taper le pays, et entrer
            dropdownInput = driver.FindElement(By.Id("edit-field-domaine-etudes-selectized"));
            dropdownInput.SendKeys(Keys.Backspace);
            dropdownInput.SendKeys(users[2].Domaine);
            dropdownInput.SendKeys(Keys.Enter);

            dropdownInput = driver.FindElement(By.Id("edit-field-niveaux-etude-selectized"));
            dropdownInput.SendKeys(Keys.Backspace);
            dropdownInput.SendKeys(users[2].Niveau);
            dropdownInput.SendKeys(Keys.Enter);


            //driver.FindElement(By.XPath("//*[@id=\"edit-field-accepte-communications-value\"]")).Click();
            // Vérifier que le label du bouton de validation du formulaire
            Assert.AreEqual("Créer un compte", driver.FindElement(By.Id("edit-submit")).GetAttribute("value"));


            // Vérifier que le statut sélectionné est "Etudiant"
            Assert.IsTrue(driver.FindElement(By.Id("edit-field-publics-cibles-3")).Selected, "Le bouton 'Chercheur' n'est pas sélectionné.");

            // Vérifier que le niveau sélectionné est "Licence 1", recupere le text de l'item qui est le text selectionner
            Assert.AreEqual("Licence 2", driver.FindElement(By.CssSelector("#edit-field-niveaux-etude-wrapper > div > div > div.selectize-input.items.has-options.full.has-items > div")).Text);

        }


        [Test]
        public void AccountReseacherDoctoratBiology()
        {
            driver.Navigate().GoToUrl("https://www.campusfrance.org/fr/user/register");

            //Renseigner les champs de saisie du formulaire
            //Informations de connexion
            driver.FindElement(By.XPath("//input[@placeholder='monadresse@domaine.com']")).SendKeys(users[3].AdresseMail);
            driver.FindElement(By.CssSelector("#edit-pass-pass1")).SendKeys(users[3].MotDePasse);
            driver.FindElement(By.CssSelector("#edit-pass-pass2")).SendKeys(users[3].MotDePasse);


            //Informations personnelles
            driver.FindElement(By.Id("tarteaucitronPersonalize2")).Click(); // Accepter cookies
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true); arguments[0].click();",
                    driver.FindElement(By.Id("edit-field-civilite-mr")));
            driver.FindElement(By.Id("edit-field-nom-0-value")).SendKeys(users[3].Nom);
            driver.FindElement(By.Id("edit-field-prenom-0-value")).SendKeys(users[3].Prenom);

            //Selectionner le pays de résidence
            // C'est un Input et pas un Select = récupere l'element, vider le champ, taper le pays, et entrer
            dropdownInput = driver.FindElement(By.Id("edit-field-pays-concernes-selectized"));
            dropdownInput.SendKeys(Keys.Backspace);
            dropdownInput.SendKeys(users[3].PaysResidence);
            dropdownInput.SendKeys(Keys.Enter);


            driver.FindElement(By.Id("edit-field-nationalite-0-target-id")).SendKeys(users[3].PaysNationalite);
            driver.FindElement(By.Id("edit-field-code-postal-0-value")).SendKeys(users[3].Adresse.CodePostale);
            driver.FindElement(By.Id("edit-field-ville-0-value")).SendKeys(users[3].Adresse.Ville);
            driver.FindElement(By.Id("edit-field-telephone-0-value")).SendKeys(users[3].Telephone);

            //Informations complémentaire
            //Scroller  avant de cocher le bouton radio  Chercheur
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true); arguments[0].click();",
                       driver.FindElement(By.Id("edit-field-publics-cibles-3")));


            // C'est un Input et pas un Select = récupere l'element, vider le champ, taper le pays, et entrer
            dropdownInput = driver.FindElement(By.Id("edit-field-domaine-etudes-selectized"));
            dropdownInput.SendKeys(Keys.Backspace);
            dropdownInput.SendKeys(users[3].Domaine);
            dropdownInput.SendKeys(Keys.Enter);

            dropdownInput = driver.FindElement(By.Id("edit-field-niveaux-etude-selectized"));
            dropdownInput.SendKeys(Keys.Backspace);
            dropdownInput.SendKeys(users[3].Niveau);
            dropdownInput.SendKeys(Keys.Enter);


            //driver.FindElement(By.XPath("//*[@id=\"edit-field-accepte-communications-value\"]")).Click();
            // Vérifier que le label du bouton de validation du formulaire
            Assert.AreEqual("Créer un compte", driver.FindElement(By.Id("edit-submit")).GetAttribute("value"));


            // Vérifier que le statut sélectionné est "Etudiant"
            Assert.IsTrue(driver.FindElement(By.Id("edit-field-publics-cibles-3")).Selected, "Le bouton 'Chercheur' n'est pas sélectionné.");

            // Vérifier que le niveau sélectionné est "Licence 1", recupere le text de l'item qui est le text selectionner
            Assert.AreEqual("Doctorat / PhD", driver.FindElement(By.CssSelector("#edit-field-niveaux-etude-wrapper > div > div > div.selectize-input.items.has-options.full.has-items > div")).Text);
        }


    }
}
