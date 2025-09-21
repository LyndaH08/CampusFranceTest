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
               // bat 'dotnet test TestFormulaireCampusFrance.sln --logger "trx;LogFileName=TestResults.trx"'
bat """dotnet test TestFormulaireCampusFrance.sln --logger "trx;LogFileName=TestResults.trx" /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=TestFormulaireCampusFrance/TestResults/coverage.opencover.xml"""
     
            }
        }
            stage('Generate HTML Report') {
              steps {
                // Restaurer les outils locaux (reportgenerator) a aprtir du ficher donet-tools.Json
                bat 'dotnet tool restore'

                // Générer le rapport HTML à partir du .trx
       bat """dotnet tool run reportgenerator -reports:TestFormulaireCampusFrance/TestResults/coverage.opencover.xml -targetdir:TestFormulaireCampusFrance/TestReport -reporttypes:HtmlSummary"""

            }
        }

    }

    post {
   always {
            echo 'Archivage et publication des résultats MSTest et HTML...'

            // Archive le fichier TRX pour Jenkins
            archiveArtifacts artifacts: 'TestFormulaireCampusFrance/TestResults/TestResults.trx', allowEmptyArchive: true

            // Publier les résultats MSTest dans Jenkins
            mstest testResultsFile: 'TestFormulaireCampusFrance/TestResults/TestResults.trx'

            // Publier le HTML généré pour visualisation
            publishHTML(target: [
                reportDir: 'TestFormulaireCampusFrance/TestReport',
                reportFiles: 'index.html',
                reportName: 'Test Report HTML',
                keepAll: true,
                alwaysLinkToLastBuild: true
            ])
        }
}
}
