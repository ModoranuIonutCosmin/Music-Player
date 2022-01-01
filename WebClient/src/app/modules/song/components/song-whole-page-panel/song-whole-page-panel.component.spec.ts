import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SongWholePagePanelComponent } from './song-whole-page-panel.component';

describe('SongWholePagePanelComponent', () => {
  let component: SongWholePagePanelComponent;
  let fixture: ComponentFixture<SongWholePagePanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SongWholePagePanelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SongWholePagePanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
