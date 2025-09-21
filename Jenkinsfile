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
                // Restaurer les packages NuGet
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
                // Créer le dossier TestResults si nécessaire
                bat 'if not exist TestFormulaireCampusFrance/TestResults mkdir TestFormulaireCampusFrance/TestResults'

                // Lancer les tests NUnit avec couverture
                bat """dotnet test TestFormulaireCampusFrance.sln ^
    --logger "trx;LogFileName=TestResults.trx" ^
    /p:CollectCoverage=true ^
    /p:CoverletOutputFormat=opencover ^
    /p:CoverletOutput=TestFormulaireCampusFrance\\TestResults\\coverage.opencover"""
            }
        }

        stage('Generate HTML Report') {
            steps {
                // Restaurer les outils locaux (reportgenerator)
                bat 'dotnet tool restore'

                // Générer le rapport HTML à partir du fichier de couverture
                bat """dotnet tool run reportgenerator ^
    -reports:TestFormulaireCampusFrance/TestResults/coverage.opencover.xml ^
    -targetdir:TestFormulaireCampusFrance/TestReport ^
    -reporttypes:HtmlSummary"""
            }
        }
    }

    post {
        always {
            echo 'Archivage et publication des résultats MSTest et HTML...'

            // Archiver le fichier TRX
            archiveArtifacts artifacts: 'TestFormulaireCampusFrance/TestResults/TestResults.trx', allowEmptyArchive: true

            // Publier les résultats MSTest
            mstest testResultsFile: 'TestFormulaireCampusFrance/TestResults/TestResults.trx'

            // Publier le HTML généré
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
