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
                bat 'dotnet test TestFormulaireCampusFrance.sln --logger "trx;LogFileName=TestResults.trx"'
        
            }
        }
            stage('Generate HTML Report') {
            steps {
                // Installer ReportGenerator 
                bat 'dotnet tool install -g dotnet-reportgenerator-globaltool || echo "Tool already installed"'


                // Générer le rapport HTML à partir du .trx
                bat 'dotnet reportgenerator -reports:TestFormulaireCampusFrance/TestResults/TestResults.trx -targetdir:TestFormulaireCampusFrance/TestReport -reporttypes:Html'
           
            }
        }

    }

    post {
   always {
            echo 'Archivage et publication des résultats MSTest et HTML...'

            // Archive tout le dossier TestResults (trx + HTML)
            archiveArtifacts artifacts: 'TestFormulaireCampusFrance/TestResults/**', allowEmptyArchive: true

            // Publier le .trx dans Jenkins (tableau MSTest)
            mstest testResultsFile: 'TestFormulaireCampusFrance/TestResults/TestResults.trx'

            // Publier le rapport HTML dans Jenkins (lien cliquable)
            publishHTML(target: [
                reportDir: 'TestFormulaireCampusFrance/TestResults/TestReport',
                reportFiles: 'index.html',
                reportName: 'Test Report HTML',
                keepAll: true,
                alwaysLinkToLastBuild: true
            ])
        }
}
}
