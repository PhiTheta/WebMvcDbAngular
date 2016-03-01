registrationModule.controller("CoursesController", function($scope, bootstrappedData) {
    $scope.courses = bootstrappedData.courses;

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

    $scope.filterFunc = function (element)
    {       
        if ($scope.search.all) {
            return element.enrollmentID == $scope.search.all ||
                element._Student.firstMidName.indexOf($scope.search.all) >= 0 ||
                element._Student.lastName.indexOf($scope.search.all) >= 0 ||
                element._Course.title.indexOf($scope.search.all) >= 0 ||
                element._Course.credits == $scope.search.all;
        }
        else if ($scope.search.id){
            return $scope.search.id == element.enrollmentID;
        }
        else if ($scope.search.sirName){
            return element._Student.firstMidName.indexOf($scope.search.sirName) >= 0;
        }
        else if ($scope.search.lastName){
            return element._Student.lastName.indexOf($scope.search.lastName) >= 0;
        }
        else if ($scope.search.course){
            return element._Course.title.indexOf($scope.search.course) >= 0;
        }
        else if ($scope.search.credit){
            return $scope.search.credit == element._Course.credits;
        }
        return true;
    }

    //$scope.filter = "$";
    //$scope.filter = "$";
    //$scope.search = { enrollmentID: '', _Student.lastName: '', _Course.title: '', _Course.credits: '', $: '' };
    //$scope.changeFilterTo = function (pr) {
    //    $scope.filter = pr;
    //}

    //$scope.changeFilterAll = function(all)
    //{
    //    $scope.changeFilterId(all);
    //    $scope.changeFilterName(all);
    //    $scope.changeFilterCourse(all);
    //    $scope.changeFilterCredit(all);
    //}
    //$scope.changeFilterId = function(id)
    //{
    //    $scope.serach.id = id;
    //}
    //$scope.changeFilterName = function(name)
    //{
    //    $scope.serach.name = name;
    //}
    //$scope.changeFilterCourse = function(course){
    //    $scope.serach.course = course;
    //}
    //$scope.changeFilterCredit = function(credit){
    //    $scope.serach.credit = credit;
    //}

});