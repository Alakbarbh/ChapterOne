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


    //get products by author 
    $(document).on("click", ".author", function (e) {

        e.preventDefault();
        let authorId = $(this).attr("data-id");
        let parent = $(".product-list")
        $.ajax({

            url: `/shop/GetProductByAuthor?id=${authorId}`,
            type: "Get",

            success: function (res) {
                $(parent).html(res);
            }
        })

    })



    ////get products by author 
    $(document).on("click", ".genre", function (e) {

        e.preventDefault();
        let genreId = $(this).attr("data-id");
        let parent = $(".product-list")
        $.ajax({

            url: `/shop/GetProductByGenre?id=${genreId}`,
            type: "Get",

            success: function (res) {
                $(parent).html(res);
            }
        })

    })



    //get all products by category  on click All
    $(document).on("click", ".all-product", function (e) {

        e.preventDefault();
        let parent = $(".product-list")
        $.ajax({

            url: "shop/GetAllProduct",
            type: "Get",

            success: function (res) {
                $(parent).html(res);
            }
        })

    })


    $(document).on("click", ".product-tag", function (e) {

        e.preventDefault();
        let tagId = $(this).attr("data-id");
        let parent = $(".product-list")
        $.ajax({

            url: `shop/GetProductsByTag?id=${tagId}`,
            type: "Get",

            success: function (res) {
                $(parent).html(res);
            }
        })

    })


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

})