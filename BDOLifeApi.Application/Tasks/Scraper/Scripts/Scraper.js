//////Cooking and Alchemy
////$('a[href*="/recipe/"][class*="qtooltip"]').each(function (index, value) {
////    let bdoId = parseInt($(this).attr('data-id').replace('recipe--', ''));
////    let name = $(this).find('b').html().replace('<span></span>', '');
////    let tier = $(this).attr('class').split(' ')[1].replace('item_grade_', '');
////    console.log(`{ "BDOReference": ${bdoId}, "Name": "${name}", "Tier": ${tier} },`);
////});

//////Proccess
////$('a[href*="/mrecipe/"][class*="qtooltip"]').each(function (index, value) {
////    let bdoId = parseInt($(this).attr('data-id').replace('mrecipe--', ''));
////    let name = $(this).find('b').html().replace('<span></span>', '');
////    let tier = $(this).attr('class').split(' ')[1].replace('item_grade_', '');
////    console.log(`{ "BDOReference": ${bdoId}, "Name": "${name}", "Tier": ${tier} },`);
////});

//Other Alternative
//let jqueryInject = document.createElement('script');
//jqueryInject.setAttribute("src", "https://code.jquery.com/jquery-3.6.0.min.js");
//jqueryInject.setAttribute("integrity", "sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=");
//jqueryInject.setAttribute("crossorigin", "anonymous");
//document.head.appendChild(jqueryInject);

let table = $('.dataTable ').DataTable()
let data = table.rows().data();
let result = [];
data.each((x, y) => {
    //BEGIN GENERIC
    let bdoId = x[0];
    let name = x[2].substring(x[2].indexOf('<b>') + 3, x[2].indexOf('</b>')).replace('<span>', '').replace('</span>', '');
    //name = JSON.stringify(name);
    let image = x[1].substring(x[1].indexOf('src="') + 5, x[1].indexOf('.webp"') + 5);
    let exp = x.length > 5 && typeof x[5] == "string" ? x[5].replace("'", "") : "";
    exp = exp == "" ? "0" : exp;
    let subType = x[3];

    let productsArray = '[';
    if (x[7] && x[7].split('item--').length > 2) {
        let product1 = x[7].split('item--').slice(1, 3)[0].split(' ')[0].replace('"', '').replace('\\', '');
        let product2 = x[7].split('item--').slice(1, 3)[1].split(' ')[0].replace('"', '').replace('\\', '');
        productsArray += `${product1},${product2}`;
    }
    else if (x[7]) {
        let product1 = x[7].split('item--').slice(1, 3)[0].split(' ')[0].replace('"', '').replace('\\', '');
        productsArray += product1;
    }
    productsArray += ']';

    if (window.location.href.includes("recipe")) {
        result.push({ "BDOReference": bdoId, "Name": name, "Image": image, "Exp": exp, "SubType": subType, "Products": productsArray });
        //result += `{ "BDOReference": ${bdoId}, "Name": ${name}, "Image": "${image}", "Exp": ${exp}, "SubType": "${subType}", "Products": ${productsArray} },`;
    }
    else {
        result.push({ "BDOReference": bdoId, "Name": name, "Image": image });
        //result += `{ "BDOReference": ${bdoId}, "Name": ${name}, "Image": "${image}" },`;
    }
})

let dataStr = "data:text/json;charset=utf-8," + encodeURIComponent(JSON.stringify(result));
let downloadAnchorNode = document.createElement('a');
downloadAnchorNode.setAttribute("href", dataStr);
let urlSplited = window.location.href.replace("https://bdocodex.com/", "").split('/');
let fileName = "";
if (urlSplited[2] !== '') {
    fileName = `${urlSplited[2]}_${urlSplited[0]}.json`;
}
else {
    fileName = `${urlSplited[1]}_${urlSplited[0]}.json`;
}
downloadAnchorNode.setAttribute("download", fileName);
document.body.appendChild(downloadAnchorNode); // required for firefox
downloadAnchorNode.click();
downloadAnchorNode.remove();


//https://bdocodex.com/tip.php?id=item--9002&l=pt&nf=on
//https://bdocodex.com/tip.php?id=mrecipe--1846&enchant=0&l=pt&nf=on
//https://bdocodex.com/tip.php?id=recipe--27&l=pt&nf=on


//https://bdocodex.com/pt/items/materials/
//https://bdocodex.com/pt/items/powerup/
//https://bdocodex.com/pt/items/consumables/
//https://bdocodex.com/pt/items/tools/
//https://bdocodex.com/pt/items/stones/
//https://bdocodex.com/pt/items/gems/
//https://bdocodex.com/pt/items/boat/
//https://bdocodex.com/pt/items/pearls/
//https://bdocodex.com/pt/items/mounts/
//https://bdocodex.com/pt/items/carriage/
//https://bdocodex.com/pt/items/furniture/
//
