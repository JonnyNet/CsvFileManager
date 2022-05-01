import { Store } from './store';

class AuthState {
  user!: any;
  error!: any;
}

class TestStore extends Store<AuthState>{
  constructor() {
    super({
      user: undefined,
      error: undefined,
    });
  }

  testState(): void {
    this.setState({
      ...this.state,
      user: 'test',
    });
  }
}

describe('Store', () => {
  it('should create an instance', () => {
    expect(new TestStore()).toBeTruthy();
  });

  it('should test get and test status', () => {
    const store = new TestStore();
    store.testState();
  });
});