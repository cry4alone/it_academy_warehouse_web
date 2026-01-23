import TableWorkInProgress from './table/TableWorkInProgress';
import { WorkInProgressProvider } from './Context';
import { Buttons } from './buttons/Buttons';

export const WorkInProgressPage = () => {

    return (
        <>
            <WorkInProgressProvider>
                <TableWorkInProgress
                />
                <div className="button-container">
                    <Buttons />
                </div>
            </WorkInProgressProvider>
        </>
    );
}

