 
mainmodule.controller('LoginController', ['$scope', '$state', '$rootScope', '$modal', '$http', '$cookies', 'toastr', '$dao',  
    function ($scope, $state, $rootScope, $modal, $http, $cookies, toastr, $dao) {
        $scope.UserName = "Trần Nhựt Anh";
        $scope.goToMain = function () {
            $state.go('main');
            return;
        };
        $scope.Login = function () {
            $scope.goToMain();
        }


    }]);  