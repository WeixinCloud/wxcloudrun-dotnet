// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
init();
function init() {
  $.ajax("/api/count", {
    method: "get",
  }).done(function (res) {
    if (res && res.data !== undefined) {
      $(".count-number").html(res.data);
    }
  });
}
function set(action) {
  $.ajax("/api/count", {
    method: "POST",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    data: JSON.stringify({
      action: action,
    }),
  }).done(function (res) {
    if (res && res.data !== undefined) {
      $(".count-number").html(res.data);
    }
  });
}
