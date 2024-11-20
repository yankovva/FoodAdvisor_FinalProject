
function PagerClick(index) {
    const pager = document.getElementById("hiddenCurrentPageIndex");
    
   pager.value = index;
    document.getElementById("theForm").submit();
}
