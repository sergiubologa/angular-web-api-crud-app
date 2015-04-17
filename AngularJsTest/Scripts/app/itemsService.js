var itemsServices = angular.module('itemsServices', ['ngResource']);

itemsServices.factory('Items', ['$resource',
  function ($resource) {
      return $resource('/api/items/:id', {}, {
          query: { method: 'GET', params: {}, isArray: true },
          get: { method: 'GET', params: { id: '@id' } },
          add: { method: 'POST', params: { description: '@description', measure: '@measure', um: '@um' } },
          edit: { method: 'PUT', params: { id: '@id', description: '@description', measure: '@measure', um: '@um' } },
          delete: { method: 'DELETE', params: { id: '@id' } }
      });
  }]);

itemsServices.factory('UnitsOfMeasure', ['$resource',
  function ($resource) {
      return $resource('/api/unitsofmeasure', {}, {
          query: { method: 'GET', params: {}, isArray: true }
      });
  }]);