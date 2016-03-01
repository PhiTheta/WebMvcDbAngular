var app = angular.module('plunker', []);

app.factory('myService', function ($http) {
    alert("erwesfsdvxc 2");
    return {
        async: function () {
            alert("erwesfsdvxc 3");
            return $http.get('~/Courses/DataGet');  //1. this returns promise
        }
    };
});

app.controller('MainCtrl', function (myService, $scope) {
    myService.async().then(function (d) { //2. so you can use .then()
        alert("erwesfsdvxc");
        $scope.courses = d;
    });

    $scope.orderByMe = function (x) {
        //alert("TEST");
        $scope.myOrderBy = x;
        if ($scope.order == "") {
            $scope.order = "reverse";
        }
        else {
            $scope.order = "";
        }
    }

    $scope.filterFunc = function (element) {
        if ($scope.search.all) {
            return element.enrollmentID == $scope.search.all ||
                element._Student.firstMidName.indexOf($scope.search.all) >= 0 ||
                element._Student.lastName.indexOf($scope.search.all) >= 0 ||
                element._Course.title.indexOf($scope.search.all) >= 0 ||
                element._Course.credits == $scope.search.all;
        }
        else if ($scope.search.id) {
            return $scope.search.id == element.enrollmentID;
        }
        else if ($scope.search.sirName) {
            return element._Student.firstMidName.indexOf($scope.search.sirName) >= 0;
        }
        else if ($scope.search.lastName) {
            return element._Student.lastName.indexOf($scope.search.lastName) >= 0;
        }
        else if ($scope.search.course) {
            return element._Course.title.indexOf($scope.search.course) >= 0;
        }
        else if ($scope.search.credit) {
            return $scope.search.credit == element._Course.credits;
        }
        return true;
    }


});



//var StudentApp = angular.module('StudentApp', []);

//StudentApp.controller('StudentController', function ($scope, StudentService) {



//    getStudents();

//    function getStudents() {

//        StudentService.getStudents()

//            .success(function (studs) {

//                $scope.students = studs;

//                console.log($scope.students);

//            })

//            .error(function (error) {

//                $scope.status = 'Unable to load customer data: ' + error.message;

//                console.log($scope.status);

//            });

//    }

//});



//StudentApp.factory('StudentService', ['$http', function ($http) {



//    var StudentService = {};

//    StudentService.getStudents = function () {

//        return $http.get('/Courses/DataGet');

//    };

//    return StudentService;



//}]);

//githubViewer.factory('ScriptService', ['$http', function ($http) {

//    var ScriptService = {};

//    ScriptService.getStudents = function () {

//        alert("111");
//        return $http.get('/Courses/DataGet');

//    };

//    return StudentService;

//}]);