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

    }

    post {
    always {
        echo 'Archivage et publication des résultats de tests...'
        
        // Archive le fichier .trx même si les tests ont échoué
        archiveArtifacts artifacts: 'TestFormulaireCampusFrance/TestResults/TestResults.trx', allowEmptyArchive: true
        
        // Publie le rapport NUnit
          step([$class: 'NUnitPublisher',
              testResultsPattern: 'TestFormulaireCampusFrance/TestResults/TestResults.trx',
              debug: false,
              keepJUnitReports: true,
              skipJUnitArchiver: false])
    }
}
}
