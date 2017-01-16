(function (app) {
    'use strict';
    app.controller("HomeController", function($scope , $http) {
        var vm = this;

        vm.MakeID = null;
        vm.ModelID = null;
        vm.MakeList = [];
        vm.ModelList = [];
        vm.Anunts = [];
        vm.Result = "";
        vm.priceMin = "";
        vm.priceMax = "";
        //HERE STARTS the Min
        vm.myMin = function () {

            vm.priceMax = (vm.priceMin && vm.priceMin > vm.priceMax) ? undefined : vm.priceMax;
        };
        vm.myMax = function () {
            vm.priceMin = (vm.priceMax && vm.priceMax < vm.priceMin) ? undefined : vm.priceMin;
        };
        vm.myNumbers = function (search) {

            var newNumbers = vm.allNumbers.slice();
            if (search && newNumbers.indexOf(search) === -1) {
                newNumbers.unshift(search);
            }

            return newNumbers;
        };
        vm.allNumbers = [1000, 2000, 3000, 5000, 10000, 12000, 15000,
           20000, 25000, 30000, 50000];
        
       //here ends

        $http.get('api/MyApi/GetMake').then(function (response) {
            vm.MakeList = response.data;
        }, function (error) {
            alert('error make');
        });

        vm.GetModel = function () {
            vm.ModelID = '';
            vm.ModelList = [];

            
            $http.get('api/MyApi/GetModel/'+ vm.MakeID).then(function (response) {
                vm.ModelList = response.data;
            });
        }

        

        vm.Search = function () {
            vm.MakeID = vm.MakeID || 0;
            vm.ModelID = vm.ModelID || 0;
            var search = {
                priceMin: parseInt(vm.priceMin) ,
                priceMax: parseInt(vm.priceMax)
            };



            $http.get('api/MyApi/GetAnunt/Make/' + vm.MakeID + '/Model/' + vm.ModelID + '/Filter' , {params: search})
                .then(function (response) {
                         vm.Anunts = response.data;
                });
                   
        }
    })
    .factory("LocationService", function($http) {
        var fac = {};
        //fac.GetMake = function () {
        //    return $http.get('api/MyApi/GetMake');
        //}
        //fac.GetModel = function (makeID) {
        //    return $http.get('api/MyApi/GetModel/'+ makeID);
        //}
        //fac.GetAnunt = function (makeID, modelID) {
        //    makeID = makeID || 0;
        //    modelID = modelID || 0;
        //    return $http.get('api/MyApi/GetAnunt/Make/'+makeID +'/Model/' + modelID+'/Filter');
        //}
        
        return fac;

    });
})(angular.module("myApp"));