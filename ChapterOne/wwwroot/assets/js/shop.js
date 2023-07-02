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


    ////get products by category  on click category
    $(document).on("click", ".genre", function (e) {

        e.preventDefault();
        let colorId = $(this).attr("data-id");
        let parent = $(".product-list")
        $.ajax({

            url: `shop/GetProductByCategory?id=${colorId}`,
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

})