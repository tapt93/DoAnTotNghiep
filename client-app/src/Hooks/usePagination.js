import { useState } from 'react'

export function usePagination(defautPageSize) {
  const [paging, setPaging] = useState({ pageSize: defautPageSize ? defautPageSize : 10, currentPage: 1, rowsCount: 0 })

  function onPageSizeChange(pageSize) {
    let updatePaging = { ...paging };
    updatePaging.currentPage = 1;
    updatePaging.pageSize = pageSize;
    setPaging(updatePaging);
  };

  function onPageChange(page) {
    let updatePaging = { ...paging };
    updatePaging.currentPage = page;
    setPaging(updatePaging);
  };

  return [paging, setPaging, onPageChange, onPageSizeChange]
}