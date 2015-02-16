var numberToWordModule = angular.module("numberToWord", []);

//numberToWordModule.config(function ($routeProvider) {
//    $routeProvider.when('/')
//});

numberToWordModule.controller('numberToWordController', function ($scope, $http, numberToWordService) {
    $scope.convertNumber = function () {
        $scope.loading = true;
        $scope.convertResult = "";
        var promise = numberToWordService.convertNumber($scope.number);
        promise.then(function(result) {
                $scope.convertResult = result;
                $scope.loading = false;
            },
            function(error) {
                
            });
    };
});

numberToWordModule.factory('numberToWordService', function ($http, $q) {
    return{
        convertNumber: function (numberToConvert) {
            var defered = $q.defer();
            $http.post("/", { number: numberToConvert }).success(function(result) {
                defered.resolve(result);
            }).error(function() {
                
            });
            return defered.promise;
        }
    }

});

numberToWordModule.directive('loading', function () {
    return {
        restrict: 'E',
        replace:true,
        template: '<img src="/Content/themes/outlook/img/prettyPhoto/facebook/loader.gif" class="spinner"/>',
        link: function (scope, element, attr) {
            scope.$watch('loading', function (val) {
                if (val)
                    $(element).show();
                else
                    $(element).hide();
            });
        }
    }
})