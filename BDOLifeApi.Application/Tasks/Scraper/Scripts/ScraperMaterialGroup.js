let recipeMaterials = [];
$('hr_long > .toggle').each(function (index, element) {
    let quantity = $(this).find('.counter_value').attr('data-material');
    let item = $(this).find('.iconset_wrapper_big > .qtooltip').attr('data-id');
    let itemId = null;
    let materialGroupId = null;
    console.log(item)
    if (item.indexOf('materialgroup') >= 0)
        materialGroupId = item.replace('materialgroup--', '');

    if (item.indexOf('item') >= 0)
        itemId = item.replace('item--', '');

    let subRecipeId = $(this).find('.sub_materials').attr('data-id');
    if (subRecipeId == undefined)
        subRecipeId = null;

    recipeMaterials.push({ itemId, materialGroupId, subRecipeId, quantity });
});

let recipeProducts = [];
$($("td > span.yellow_text:contains('- Resultado da Manufatura')").parent()).find('.iconset_wrapper_medium > .qtooltip').each(function (index, element) {
    let id = $(this).attr('data-id').replace('item--', '');
    recipeProducts.push({ id });
})

