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
                // Restaurer les packages NuGet si nécessaire
                bat 'dotnet restore TestFormulaireCampusFrance/TestFormulaireCampusFrance.sln'
            }
        }

        stage('Build') {
            steps {
                // Compiler le projet
                bat 'dotnet build TestFormulaireCampusFrance/TestFormulaireCampusFrance.sln --configuration Debug'
            }
        }

        stage('Test') {
            steps {
                // Lancer les tests NUnit
                bat 'dotnet test TestFormulaireCampusFrance/TestFormulaireCampusFrance.sln --logger "trx;LogFileName=TestResults.trx"'
            }
        }
    }

    post {
        always {
            // Archive les résultats de test
            archiveArtifacts artifacts: '**/TestResults/*.trx', allowEmptyArchive: true
        }
        success {
            echo 'Pipeline terminée avec succès !'
        }
        failure {
            echo 'Pipeline échouée !'
        }
    }
}
