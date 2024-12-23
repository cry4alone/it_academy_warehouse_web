import React from 'react';
import TableWorkInProgress from '../components/table/TableWorkInProgress'


function WorkInProgress() {
    return (
        <>
           <div className="tab__title">Незавершённое производство</div>
           <TableWorkInProgress />
        </>
    );
}

export default WorkInProgress;