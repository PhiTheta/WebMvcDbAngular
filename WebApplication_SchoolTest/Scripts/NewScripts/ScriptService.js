
var StudentApp = angular.module('StudentApp', []);

StudentApp.controller('StudentController', function ($scope, StudentService) {



    getStudents();

    function getStudents() {

        StudentService.getStudents()

            .success(function (studs) {

                $scope.students = studs;

                console.log($scope.students);

            })

            .error(function (error) {

                $scope.status = 'Unable to load customer data: ' + error.message;

                console.log($scope.status);

            });

    }

});



StudentApp.factory('StudentService', ['$http', function ($http) {



    var StudentService = {};

    StudentService.getStudents = function () {

        return $http.get('/Courses/DataGet');

    };

    return StudentService;



}]);

//githubViewer.factory('ScriptService', ['$http', function ($http) {

//    var ScriptService = {};

//    ScriptService.getStudents = function () {

//        alert("111");
//        return $http.get('/Courses/DataGet');

//    };

//    return StudentService;

//}]);