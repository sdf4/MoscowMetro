function stationsController($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    //Used to display the data 
    $http.get('/Stations/Get').then(function (response) {
        
        $scope.Stations = response.data;
        $scope.loading = false;

    }, function (error) {
        $scope.error = "error";
        $scope.loading = false;
    });

}

function metroRoutesController($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    //Used to display the data 
    $http.get('/MetroRoutes/Get').then(function (response) {

        $scope.MetroRoutes = response.data;
        $scope.loading = false;

    }, function (error) {
        $scope.error = "error";
        $scope.loading = false;
    });

    $scope.toggleEdit = function () {
        this.Station.editMode = !this.Contact.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    //Used to add a new record 
    $scope.add = function (newRoute) {
        $scope.loading = true;
        $http.post('/MetroRoutes/Create/', newRoute).then(function (response) {  
            $scope.addMode = false;
            $scope.MetroRoutes = response.data;
            $scope.loading = false;
        }, function (error) {
            console.log(error);
            $scope.error = "An Error has occured while Adding! ";
            $scope.loading = false;
        });
    };


    $scope.delete = function (route) {
 
        $http.post('/MetroRoutes/Delete/' + route.id).then(function (response) {

            $scope.MetroRoutes = response.data;

        }, function (error) {
            console.log(error);
            $scope.error = "delete error";
        });
    };

    
}

var MoscowMetroApp = angular.module('MoscowMetroApp', ['ngRoute']);

MoscowMetroApp.controller('stationsController', stationsController);
MoscowMetroApp.controller('metroRoutesController', metroRoutesController);


MoscowMetroApp.config(['$httpProvider', function ($httpProvider) {
    var antiForgeryToken = document.getElementById('antiForgeryForm').childNodes[1].value;
    $httpProvider.defaults.headers.post['__RequestVerificationToken'] = antiForgeryToken;
}]);
