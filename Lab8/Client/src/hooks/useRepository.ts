import { IModel } from '../models/index';
import Repository from '../services/Repository';

import config from '../config';

const useRepository = <Model extends IModel>(model: string) => {
    return new Repository<Model>(config.apiurl + '/' + model);
};

export default useRepository;