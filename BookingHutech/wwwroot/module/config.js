/////// <reference path="../../script/js/jquery.min.js" /> 
/////// <reference path="../../script/js/custom.min.js" />
///// <reference path="../controller/maincontroller.js" />

mainmodule.config(function ($stateProvider, $urlRouterProvider, $locationProvider, KeepaliveProvider, IdleProvider) {
    $urlRouterProvider.otherwise(function ($injector, $location) {
        var state = $injector.get('$state');
        var location = $location.path();
        if (location === "") {
            state.go("login");
        }
        else {
            state.go("error404");
        }
    });
    $stateProvider
        .state('login', {
            url: '/dang-nhap',
            templateUrl: '/wwwroot/views/pages/account/login.html',
            controller: 'LoginController', 
        }) 
        .state('main', {
            url: '/main',
            templateUrl: '/wwwroot/views/main.html',
            controller: 'mainController',
        })
        .state('main.home', {
            url: '/trang-chu',
            templateUrl: '/wwwroot/views/pages/home/home.html',
            controller: 'HomeController',
        })  
        .state('error404', {
            url: '/error404',
            templateUrl: '/wwwroot/views/common/error/error404.html',
            //controller: '404controller',
        });

});
mainmodule.config(['$translateProvider',
    function ($translateProvider) {

        var $cookies;   // init cookies for init below
        angular.injector(['ngCookies']).invoke(['$cookies', function (_$cookies_) {
            $cookies = _$cookies_;
        }]);

        $translateProvider.translations('en', {
            /* -------- Menu Name ---------- */
            'ManageProfile': 'Quản lý hồ sơ',
        });


        $translateProvider.translations('vn', {
            /* --------  Menu Name ---------- */
            'ManageProfile': 'Quản lý hồ sơ',


        });

        var language = $cookies.get('language');

        if (language == 'en')
            $translateProvider.preferredLanguage('en')
        else
            $translateProvider.preferredLanguage('vn')  //default

        $translateProvider.useSanitizeValueStrategy(null);

        // $translateProvider.useSanitizeValueStrategy('sanitize');
    }
]);
