pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                // Récupérer le code depuis GitHub
                git branch: 'main', url: 'https://github.com/LyndaH08/CampusFranceTest.git'
            }
        }

        stage('Restore Packages') {
            steps {
                // Restaurer les packages NuGet (Télécharger et préparer toutes les dépendances NuGet du projet)
                bat 'dotnet restore TestFormulaireCampusFrance.sln'
            }
        }

        stage('Build') {
            steps {
                // Compiler le projet
                bat 'dotnet build TestFormulaireCampusFrance.sln --configuration Debug'
            }
        }

        stage('Test') {
            steps {
                // Lancer les tests NUnit
                //bat 'dotnet test TestFormulaireCampusFrance.sln --logger "trx;LogFileName=TestResults.trx"'
               // bat 'dotnet test TestFormulaireCampusFrance.sln --logger "nunit;LogFileName=TestResults.xml"'
                // Lancer les tests avec NUnit Console Runner
               bat '"packages\\NUnit.ConsoleRunner.3.17.0\\tools\\nunit3-console.exe" bin\\Debug\\net8.0\\CampusFrance.test.dll --result=TestResults.xml;format=nunit2'


            }
        }

    }

    post {
    always {
        echo 'Archivage et publication des résultats NUnit...'
        
        // Archive le fichier NUnit XML
        archiveArtifacts artifacts: 'TestFormulaireCampusFrance/TestResults.xml', allowEmptyArchive: true
        
        // Publie le rapport NUnit
        step([$class: 'NUnitPublisher',
              testResultsPattern: 'TestFormulaireCampusFrance/TestResults.xml',
              debug: false,
              keepJUnitReports: true,
              skipJUnitArchiver: false])
    }
}
}
