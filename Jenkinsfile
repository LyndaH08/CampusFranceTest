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
      
    stage('Publish Test Results') {
            steps {
                echo 'Publication des résultats de tests...'

                // Archive les résultats pour qu’ils soient consultables depuis Jenkins
                archiveArtifacts artifacts: "**/TestResults/*.trx", allowEmptyArchive: true

                // Publie un rapport lisible via le plugin NUnit
                step([$class: 'NUnitPublisher', testResults: "**/TestResults/*.trx"])
            }
        }

    }
}
