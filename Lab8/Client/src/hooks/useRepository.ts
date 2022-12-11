import { useMutation, useQuery, useQueryClient } from 'react-query';

import Repository from '../services/Repository';

import { IModel } from '../models/index';
import config from '../config';

const useRepository = <Model extends IModel>() => {
    const client = useQueryClient();
    const service = new Repository<Model>(config.apiurl);

    const refetch = () => {
        client.invalidateQueries(service.apiurl);
    };

    const queryAll = useQuery(
        service.apiurl,
        async () => await service.getAll()
    );

    const createQuery = useMutation(
        async (model: Model) => await service.create(model),
        {
            onSuccess: (result) => {
                client.setQueriesData([service.apiurl, result.id], result);
                refetch();
            }
        }
    );

    const updateQuery = useMutation(
        async ({id, model}: { id: number, model: Model }) => await service.update(id, model),
        {
            onSuccess: (result) => {
                client.setQueriesData([service.apiurl, result.id], result);
                refetch();
            }
        }
    );

    const deleteQuery = useMutation(
        async (id: number) => await service.delete(id),
        {
            onSuccess: () => refetch()
        }
    );

    return {
        refetch,
        queryAll,
        createQuery,
        updateQuery,
        deleteQuery
    }
};

export default useRepository;