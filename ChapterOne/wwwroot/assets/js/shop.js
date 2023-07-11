$(document).ready(function () {

  //-------price filtre --star------------

  let minValue = document.getElementById("min-value");
  // console.log(minValue);
  let maxValue = document.getElementById("max-value");

  function validateRange(minPrice, maxPrice) {
    if (minPrice > maxPrice) {
      // Swap to Values
      let tempValue = maxPrice;
      maxPrice = minPrice;
      minPrice = tempValue;
    }

    minValue.innerHTML = "$" + minPrice;
    maxValue.innerHTML = "$" + maxPrice;
  }

  const inputElements = document.querySelectorAll(".range-slider input");
  inputElements.forEach((element) => {
    element.addEventListener("change", (e) => {
      let minPrice = parseInt(inputElements[0].value);
      let maxPrice = parseInt(inputElements[1].value);

      validateRange(minPrice, maxPrice);
    });
  });

    validateRange(inputElements[0].value, inputElements[1].value);


    ////get products by author 
    //$(document).on("click", ".author", function (e) {

    //    e.preventDefault();
    //    let authorId = $(this).attr("data-id");
    //    let parent = $(".product-list")
    //    $.ajax({

    //        url: `/shop/GetProductByAuthor?id=${authorId}`,
    //        type: "Get",

    //        success: function (res) {
    //            $(parent).html(res);
    //        }
    //    })

    //})



    //////get products by author 
    //$(document).on("click", ".genre", function (e) {

    //    e.preventDefault();
    //    let genreId = $(this).attr("data-id");
    //    let parent = $(".product-list")
    //    $.ajax({

    //        url: `/shop/GetProductByGenre?id=${genreId}`,
    //        type: "Get",

    //        success: function (res) {
    //            $(parent).html(res);
    //        }
    //    })

    //})



    //get all products by category  on click All
    //$(document).on("click", ".all-product", function (e) {

    //    e.preventDefault();
    //    let parent = $(".product-list")
    //    $.ajax({

    //        url: "shop/GetAllProduct",
    //        type: "Get",

    //        success: function (res) {
    //            $(parent).html(res);
    //        }
    //    })

    //})


    //$(document).on("click", ".product-tag", function (e) {

    //    e.preventDefault();
    //    let tagId = $(this).attr("data-id");
    //    let parent = $(".product-list")
    //    $.ajax({

    //        url: `shop/GetProductsByTag?id=${tagId}`,
    //        type: "Get",

    //        success: function (res) {
    //            $(parent).html(res);
    //        }
    //    })

    //})


    $(document).on("keyup", ".input-field", function () {
        $("#search-list li").slice(1).remove();
        let value = $(".input-field").val();
        $.ajax({
            url: `shop/search?searchText=${value}`,
            type: "Get",
            success: function (res) {

                $("#search-list").append(res);
            }
        })
    })


    //butun datalarin gosterilmesi
    getProducts(".all-product", "/Shop/GetAllProducts")

    function getProducts(clickedElem, url) {
        $(document).on("click", clickedElem, function (e) {
            debugger
            e.preventDefault();
            let parent = $(".product-list")
            $.ajax({
                url: url,
                type: "Get",
                success: function (res) {
                    $(parent).html(res);
                }
            })
        })

    }


    //sechimlere gore datalarin gosterilmesi
    function getProductsById(clickedElem, url) {
        $(document).on("click", clickedElem, function (e) {
            e.preventDefault();
            let id = $(this).attr("data-id");
            let data = { id: id };
            let parent = $(".product-list")
            $.ajax({
                url: url,
                type: "Get",
                data: data,
                success: function (res) {
                    $(parent).html(res);
                }
            })
        })

    }


    getProductsById(".genre", "/Shop/GetProductsByGenre")
    getProductsById(".author", "/Shop/GetProductsByAuthor")
    getProductsById(".tag", "/Shop/GetProductsByTag")



    $(function () {


        //SORT
        $(document).on("change", "#sort", function (e) {
            e.preventDefault();
            let sortValue = $(this).val();
            let data = { sortValue: sortValue };
            let parent = $(".product-list");

            $.ajax({
                url: "/Shop/Sort",
                type: "Get",
                data: data,
                success: function (res) {
                    $(parent).html(res);

                }

            })
        })



        //FILTER
        $(document).on("submit", "#filterForm", function (e) {
            e.preventDefault();
            let value1 = $(".min-price").val();
            let value2 = $(".max-price").val();
            let data = { value1: value1, value2: value2 }
            let parent = $(".product-list");
            $.ajax({
                url: "/Shop/GetRangeProducts",
                type: "Get",
                data: data,
                success: function (res) {
                    $(parent).html(res);
                    if (value1 == "10" && value2 == "500") {
                        $(".pagination").addClass("d-none")
                    }
                }
            })
        })



    })
    

})