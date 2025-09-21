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
                // Lancer les tests NUnit avec couverture
                bat """ dotnet test TestFormulaireCampusFrance.sln --logger "trx;LogFileName=TestResults.trx" """
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

        }
    }
}
