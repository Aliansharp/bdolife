function GetMaterials() {

    let recipeMaterials = [];
    $('.card.mt-3 > .card-body > .toggle').each(function (index, element) {
        let quantity = $(this).find('.counter_value').attr('data-material');
        let item = $(this).find('.iconset_wrapper_big > .qtooltip').attr('data-id');
        let itemId = null;
        let materialGroupId = null;

        if (item.indexOf('materialgroup') >= 0)
            materialGroupId = item.replace('materialgroup--', '');

        if (item.indexOf('item') >= 0)
            itemId = item.replace('item--', '');

        let subRecipeId = $(this).find('.sub_materials').attr('data-id');
        let recipeType = $(this).find('.sub_materials').attr('data-type');
        let weight = $(this).find('.material_weight.column_shift').attr('data-weight');

        if (subRecipeId == undefined)
            subRecipeId = null;

        if (recipeType == undefined)
            recipeType = null;

        weight = parseFloat(weight);

        recipeMaterials.push({ recipeType, itemId, weight, materialGroupId, subRecipeId, quantity: parseInt(quantity) });
    });

    return recipeMaterials;
}

function GetProducts() {
    let recipeProducts = [];
    $($("td > span.yellow_text:contains('- Resultado da Manufatura')").parent()).find('.iconset_wrapper_medium > .qtooltip').each(function (index, element) {
        let id = $(this).attr('data-id').replace('item--', '');
        recipeProducts.push({ id });
    });

    return recipeProducts;
}


let urlSplited = window.location.href.replace("https://bdocodex.com/", "").split('/');

let result = { id: urlSplited[2], materials: GetMaterials(), products: GetProducts() }
let fileName = `${urlSplited[1]}_${urlSplited[2]}_${urlSplited[0]}.json`;
let dataStr = "data:text/json;charset=utf-8," + encodeURIComponent(JSON.stringify(result));
let downloadAnchorNode = document.createElement('a');
downloadAnchorNode.setAttribute("href", dataStr);
downloadAnchorNode.setAttribute("download", fileName);
document.body.appendChild(downloadAnchorNode); // required for firefox
downloadAnchorNode.click();
downloadAnchorNode.remove();