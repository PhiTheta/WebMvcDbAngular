(function () {

    var app = angular.module("githubViewer", []);
    alert("888");
    var MainController = function ($scope, $http) {
        alert("333");
        // Test 3
        var onUserComplete = function (response) {
            $scope.course = response;
            alert($scope.course);
        }

        var onError = function (reason) {
            $scope.error = "Could not fetch the user";
        }

        var search = function () {
            alert("Data");
            $http.get("/Courses/DataGet")
                .then(onUserComplete, onError);
        }

        $scope.orderByMe = function (x) {
            alert("TEST");
            $scope.myOrderBy = x;
        }

        search();

        function getStudents() {
            alert("1");
            ScriptService.getStudents()

                .success(function (studs) {
                    alert("2");

                    $scope.students = studs;

                    console.log($scope.students);

                })

                .error(function (error) {
                    alert("3");

                    $scope.status = 'Unable to load customer data: ' + error.message;

                    console.log($scope.status);

                });

        };

        getStudents();

    };

    //app.factory('ScriptService', ['$http', function ($http) {

    //    var ScriptService = {};

    //    ScriptService.getStudents = function () {

    //        alert("111");
    //        return $http.get('/Courses/DataGet');

    //    };

    //    return StudentService;

    //}]);

    app.controller("MainController", ["$scope", "$http", MainController]);

}());